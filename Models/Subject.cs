using System.ComponentModel.DataAnnotations;

public class Subject
{
    [Key]
    public int SubjectKey { get; set; }

    [Required]
    public required string SubjectName { get; set; }
}