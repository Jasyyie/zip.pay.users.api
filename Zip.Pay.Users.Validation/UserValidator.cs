using FluentValidation;
using Zip.Pay.Users.Model;
using System.Collections.Generic;
public class UserValidator : AbstractValidator<User>
{
    private readonly IEnumerable<User> _user;
    public UserValidator(IEnumerable<User> user)
    {
        _user = user;
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email Required!").EmailAddress().WithMessage("A valid email address is required!");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required!");
        RuleFor(x => x.MonthlySalary).NotEmpty().WithMessage("Monthly Salary required").GreaterThanOrEqualTo(1000);
        RuleFor(x => x.MonthlyExpense).NotEmpty();
    }
}