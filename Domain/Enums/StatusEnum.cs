using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum StatusEnum
{
    Waiting,

    Completed,

    [Display(Name = "In Progress")]
    InProgress,

    [Display(Name = "Past Due")]
    PastDue

}