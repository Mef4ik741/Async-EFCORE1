﻿
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}