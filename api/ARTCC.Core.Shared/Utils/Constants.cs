namespace ARTCC.Core.Shared.Utils;

public class Constants
{
    // Nav permissions
    public const string PERMISSION_VIEW_TRAINING_MANAGEMENT = "VIEW.TRAINING.MANAGEMENT";
    public const string PERMISSION_VIEW_ARTCC_MANAGEMENT = "VIEW.ARTCC.MANAGEMENT";

    // Airport permissions
    public const string PERMISSION_CREATE_AIRPORT = "CREATE.AIRPORT";
    public const string PERMISSION_UPDATE_AIRPORT = "UPDATE.AIRPORT";
    public const string PERMISSION_DELETE_AIRPORT = "DELETE.AIRPORT";

    // Comment permissions
    public const string PERMISSION_CREATE_COMMENT = "CREATE.COMMENT";
    public const string PERMISSION_READ_COMMENT = "READ.COMMENT";
    public const string PERMISSION_READ_CONFIDENTIAL_COMMENT = "READ.CONFIDENTIAL.COMMENT";
    public const string PERMISSION_DELETE_COMMENT = "DELETE.COMMENT";

    // Event permissions
    public const string PERMISSION_CREATE_EVENT = "CREATE.EVENT";
    public const string PERMISSION_VIEW_CLOSED_EVENTS = "VIEW.CLOSED.EVENTS";
    public const string PERMISSION_UPDATE_EVENT = "UPDATE.EVENT";
    public const string PERMISSION_DELETE_EVENT = "DELETE.EVENT";
    public const string PERMISSION_CREATE_EVENT_POSITION = "CREATE.EVENT.POSITION";
    public const string PERMISSION_DELETE_EVENT_POSITION = "DELETE.EVENT.POSITION";
    public const string PERMISSION_CREATE_EVENT_REGISTRATION = "CREATE.EVENT.REGISTRATION";
    public const string PERMISSION_VIEW_EVENT_REGISTRATIONS = "VIEW.EVENT.REGISTRATIONS";
    public const string PERMISSION_ASSIGN_EVENT_REGISTRATIONS = "ASSIGN.EVENT.REGISTRATIONS";

    // FAQ permissions
    public const string PERMISSION_CREATE_FAQ = "CREATE.FAQ";
    public const string PERMISSION_UPDATE_FAQ = "UPDATE.FAQ";
    public const string PERMISSION_DELETE_FAQ = "DELETE.FAQ";
}
