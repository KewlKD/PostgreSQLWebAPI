using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System;

namespace PostgreSQLWebAPI.Models
{
    public record Student
    {
       

        public string? studentid { get; set; }
        public string? studentfirstname { get; set; }
        public string? studentlastname { get; set; }
        public string? studentadd { get; set; }
        public string? studentcity { get; set; }
        public string? studentstate { get; set; }
        public string? studentemail { get; set; }
        public string? bacourse { get; set; }
       
    }
}
