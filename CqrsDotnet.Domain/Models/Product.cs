using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsDotnet.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}