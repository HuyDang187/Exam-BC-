using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC_
{
	
	public class Question
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public List<string> Options { get; set; }
		public string CorrectAnswer { get; set; }

		public Question(int id, string content, List<string> options, string correctAnswer)
		{
			Id = id;
			Content = content;
			Options = options;
			CorrectAnswer = correctAnswer;
		}
	}

	public class Exam
	{
		public int ExamId { get; set; }
		public string Name { get; set; }
		public List<Question> Questions { get; set; }

		public Exam(int examId, string name)
		{
			ExamId = examId;
			Name = name;
			Questions = new List<Question>();
		}

		public void AddQuestion(Question question)
		{
			Questions.Add(question);
		}

		public void RemoveQuestion(int questionId)
		{
			var questionToRemove = Questions.Find(q => q.Id == questionId);
			if (questionToRemove != null)
			{
				Questions.Remove(questionToRemove);
			}
		}
	}

	public class ExamManager
	{
		private List<Exam> exams;

		public ExamManager()
		{
			exams = new List<Exam>();
		}

		public void CreateExam(int examId, string name)
		{
			var exam = new Exam(examId, name);
			exams.Add(exam);
		}

		public Exam LoadExamById(int examId)
		{
			return exams.Find(exam => exam.ExamId == examId);
		}

		public void AddQuestionToExam(int examId, Question question)
		{
			var exam = LoadExamById(examId);
			if (exam != null)
			{
				exam.AddQuestion(question);
			}
		}

		public void RemoveQuestionFromExam(int examId, int questionId)
		{
			var exam = LoadExamById(examId);
			if (exam != null)
			{
				exam.RemoveQuestion(questionId);
			}
		}

		public int SubmitAnswers(int examId, Dictionary<int, string> submittedAnswers)
		{
			var exam = LoadExamById(examId);
			int score = 0;
			if (exam != null)
			{
				foreach (var question in exam.Questions)
				{
					if (submittedAnswers.ContainsKey(question.Id) && submittedAnswers[question.Id] == question.CorrectAnswer)
					{
						score++;
					}
				}
			}
			return score;
		}
	}

	class Program
	{
		static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;
			ExamManager examManager = new ExamManager();

			while (true)
			{
				Console.Clear();
				Console.WriteLine("=== MENU QUẢN LÝ ĐỀ VÀ CÂU HỎI ===");
				Console.WriteLine("1. Tạo đề thi");
				Console.WriteLine("2. Thêm câu hỏi vào đề thi");
				Console.WriteLine("3. Xóa câu hỏi khỏi đề thi");
				Console.WriteLine("4. Xem câu hỏi của đề thi");
				Console.WriteLine("5. Nộp bài thi");
				Console.WriteLine("6. Thoát");
				Console.Write("Chọn chức năng: ");

				
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.WriteLine("\n--- Tạo đề thi ---");
						Console.Write("Nhập mã đề thi: ");
						int examId = int.Parse(Console.ReadLine());
						Console.Write("Nhập tên đề thi: ");
						string examName = Console.ReadLine();
						examManager.CreateExam(examId, examName);
						Console.WriteLine("Đề thi đã được tạo thành công!");
						Console.ReadKey();
						break;

					case 2:
						Console.WriteLine("\n--- Thêm câu hỏi vào đề thi ---");
						Console.Write("Nhập mã đề thi: ");
						examId = int.Parse(Console.ReadLine());
						Console.Write("Nhập câu hỏi: ");
						string questionContent = Console.ReadLine();
						Console.WriteLine("Nhập các lựa chọn (nhập 'x' để kết thúc): ");
						List<string> options = new List<string>();
						string option;
						while ((option = Console.ReadLine()) != "x")
						{
							options.Add(option);
						}
						Console.Write("Nhập câu trả lời đúng: ");
						string correctAnswer = Console.ReadLine();
						var question = new Question(examId, questionContent, options, correctAnswer);
						examManager.AddQuestionToExam(examId, question);
						Console.WriteLine("Câu hỏi đã được thêm thành công!");
						Console.ReadKey();
						break;

					case 3:
						Console.WriteLine("\n--- Xóa câu hỏi khỏi đề thi ---");
						Console.Write("Nhập mã đề thi: ");
						examId = int.Parse(Console.ReadLine());
						Console.Write("Nhập ID câu hỏi cần xóa: ");
						int questionId = int.Parse(Console.ReadLine());
						examManager.RemoveQuestionFromExam(examId, questionId);
						Console.WriteLine("Câu hỏi đã được xóa!");
						Console.ReadKey();
						break;

					case 4:
						Console.WriteLine("\n--- Xem câu hỏi của đề thi ---");
						Console.Write("Nhập mã đề thi: ");
						examId = int.Parse(Console.ReadLine());
						var exam = examManager.LoadExamById(examId);
						if (exam != null)
						{
							Console.WriteLine($"Đề thi: {exam.Name}");
							foreach (var q in exam.Questions)
							{
								Console.WriteLine($"{q.Id}. {q.Content}");
								foreach (var option1 in q.Options)
								{
									Console.WriteLine($"   - {option1}");
								}
							}
						}
						else
						{
							Console.WriteLine("Đề thi không tồn tại.");
						}
						Console.ReadKey();
						break;

					case 5:
						Console.WriteLine("\n--- Nộp bài thi ---");
						Console.Write("Nhập mã đề thi: ");
						examId = int.Parse(Console.ReadLine());
						var submittedAnswers = new Dictionary<int, string>();
						exam = examManager.LoadExamById(examId);
						if (exam != null)
						{
							foreach (var q in exam.Questions)
							{
								Console.WriteLine($"{q.Id}. {q.Content}");
								for (int i = 0; i < q.Options.Count; i++)
								{
									Console.WriteLine($"   {i + 1}. {q.Options[i]}");
								}
								Console.Write("Chọn câu trả lời: ");
								string answer = Console.ReadLine();
								int answerIndex = int.Parse(answer);
								if (answerIndex >= 1 && answerIndex <= q.Options.Count)
								{
									submittedAnswers[q.Id] = q.Options[answerIndex - 1];
								}
							}
							int score = examManager.SubmitAnswers(examId, submittedAnswers);
							Console.WriteLine($"Điểm của bạn: {score}/{exam.Questions.Count}");
						}
						else
						{
							Console.WriteLine("Đề thi không tồn tại.");
						}
						Console.ReadKey();
						break;

					case 6:
						return;

					default:
						Console.WriteLine("Chọn không hợp lệ, vui lòng thử lại.");
						Console.ReadKey();
						break;
				}
			}
		}
	}


}
