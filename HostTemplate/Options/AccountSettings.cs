namespace HostTemplate.Options;

public class AccountSettings
{
    public const string Section = "AccountSettings";
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
