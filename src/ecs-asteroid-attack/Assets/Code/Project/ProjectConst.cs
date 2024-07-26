using UnityEngine.Device;

namespace Code.Project
{
  public static class ProjectConst
  {
    public static string CompanyName => Application.companyName;
    public static string ProjectName => Application.productName;
    public static string ProjectVersion => Application.version;
  }
}