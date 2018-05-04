<%@ Application Language="C#"%>
<Script Language="C#" Runat="Server">
	protected void Application_OnStart() {
		Application.Lock();
		Application.UnLock();
	}
</Script>