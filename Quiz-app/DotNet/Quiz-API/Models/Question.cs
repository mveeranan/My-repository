using System.ComponentModel.DataAnnotations;

namespace Quiz_API.Models
{
	public class Question
	{
		[Key]
		public int QnID { get; set; }
		public string? Qn {  get; set; }
		public string? ImageName { get; set; }
		public string? Option1 { get; set; }
		public string? Option2 { get; set; }
		public string? Option3 { get; set; }
		public string? Option4 { get; set; }
		public int? Answer {  get; set; }
	}
}
