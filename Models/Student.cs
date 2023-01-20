using System.ComponentModel.DataAnnotations;

namespace RoleBaseDemo.Models;
public class Student
{
    public int ID { get; set; }
    [StringLength(50)]
    public string LastName { get; set; }
    [StringLength(50)]
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}