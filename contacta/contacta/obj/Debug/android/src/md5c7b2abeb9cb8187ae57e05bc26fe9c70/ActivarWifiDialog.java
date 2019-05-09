package md5c7b2abeb9cb8187ae57e05bc26fe9c70;


public class ActivarWifiDialog
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("contacta.App.AppDialog.ActivarWifiDialog, contacta", ActivarWifiDialog.class, __md_methods);
	}


	public ActivarWifiDialog ()
	{
		super ();
		if (getClass () == ActivarWifiDialog.class)
			mono.android.TypeManager.Activate ("contacta.App.AppDialog.ActivarWifiDialog, contacta", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
