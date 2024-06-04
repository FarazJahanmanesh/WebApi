namespace Domain.Common;
public class IdentitySetting
{
    public int PasswordRequiredLength { get; set; }
    public int PasswordRequiredUniqueChars { get; set; }
    public bool PasswordRequireLowercase { get; set; }
    public bool PasswordRequireDigit { get; set; }
    public bool PasswordRequireUppercase { get; set; }
    public bool UserRequireUniqueEmail { get; set; }
}