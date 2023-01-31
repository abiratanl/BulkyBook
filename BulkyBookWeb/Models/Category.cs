using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Range(1, 200)]
    [Display(Name="Display Order")]
    public int DisplayOrder { get; set; }
    
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    
    
}