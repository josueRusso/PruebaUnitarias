using System;
using System.Text;

namespace PruebaUnitarias;

public class UnitTest1
{
    [Fact]
    public void IsPasswordSecure_returns_false_if_password_has_less_than_8_characters()
    {
        //Arrange
        var registerViewModel = new RegisterViewModel();

        //Act
        bool result = registerViewModel.IsPasswordSecure("1234567");

        //Assert
        Assert.False(result);

    }
    [Fact]
    public void IsPasswordSecure_returns_false_if_password_does_not_contains_uppercase_character()
    {
        //Arrange
        var registerViewModel = new RegisterViewModel();

        //Act
        bool result = registerViewModel.IsPasswordSecure("12345678a");

        //Assert
        Assert.False(result);

    }
    [Fact]
    public void IsPasswordSecure_returns_true_if_password_contains_an_uppercase_character_and_a_symbol()
    {
        // Arrange
        var registerViewModel = new RegisterViewModel();

        // Act
        bool result = registerViewModel.IsPasswordSecure("Q23D@45");

        // Assert
        Assert.False(result);
    }
}

internal class RegisterViewModel
{
    internal bool IsPasswordSecure(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }
        //1234A5678
        if (!ContieneMayuscula(password))
        {
            return false;
        }

        if (!ContieneSimbolo(password))
        {
            return false;
        }

        return true;
    }

    private bool ContieneMayuscula(string password)
    {
        char[] passwordChars = password.ToCharArray();
        foreach (char c in passwordChars)
        {
            if (Char.IsLetter(c) && IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsUpper(char c)
    {
        int codigoAscii = Convert.ToInt32(c);

        return codigoAscii >= 65 && codigoAscii <= 90;

    }

    private bool ContieneSimbolo(string password)
    {
        foreach (char c in password)
        {
            if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c))
            {
                return true;
            }
        }
        return false;
    }
}