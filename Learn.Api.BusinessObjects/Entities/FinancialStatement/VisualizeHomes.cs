using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Api.Business.Objects.Entities.FinancialStatement;

public class VisualizeHomes
{
    [Key]
    public int Code { get; set; }
    public string? NameResident { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
    public bool Service { get; set; }
    public int FinancialStatement { get; set; }
    
}
