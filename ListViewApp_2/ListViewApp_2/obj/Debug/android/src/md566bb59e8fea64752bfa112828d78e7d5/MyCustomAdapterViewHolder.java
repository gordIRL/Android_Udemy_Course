package md566bb59e8fea64752bfa112828d78e7d5;


public class MyCustomAdapterViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ListViewApp_2.MyCustomAdapterViewHolder, ListViewApp_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyCustomAdapterViewHolder.class, __md_methods);
	}


	public MyCustomAdapterViewHolder ()
	{
		super ();
		if (getClass () == MyCustomAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("ListViewApp_2.MyCustomAdapterViewHolder, ListViewApp_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
