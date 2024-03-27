using System.ComponentModel.DataAnnotations;

namespace Quiz_API.Models
{
	public class Participant
	{
		[Key]
		public int ParticipantID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int? Score { get; set; }
		public int? TimeSpent { get; set; }
	}
}
