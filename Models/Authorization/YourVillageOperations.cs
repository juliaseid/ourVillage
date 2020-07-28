using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace YourVillage.Authorization
{
  public static class YourVillageOperations
  {
    public static OperationAuthorizationRequirement Create =
      new OperationAuthorizationRequirement { Name = IdentityConstants.CreateOperationName };
    public static OperationAuthorizationRequirement Read =
      new OperationAuthorizationRequirement { Name = IdentityConstants.ReadOperationName };
    public static OperationAuthorizationRequirement Update =
      new OperationAuthorizationRequirement { Name = IdentityConstants.UpdateOperationName };
    public static OperationAuthorizationRequirement Delete =
      new OperationAuthorizationRequirement { Name = IdentityConstants.DeleteOperationName };
    public static OperationAuthorizationRequirement Note =
      new OperationAuthorizationRequirement { Name = IdentityConstants.NoteOperationName };
  }

  public class IdentityConstants
  {
    public static readonly string CreateOperationName = "Create";
    public static readonly string ReadOperationName = "Read";
    public static readonly string UpdateOperationName = "Update";
    public static readonly string DeleteOperationName = "Delete";
    public static readonly string NoteOperationName = "Note";
  }
}