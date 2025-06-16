var OpenWindowPlugin = {
    OpenWindow: function(link)
    {
    	var url = Pointer_stringify(link);
        document.onmouseup = function()
        {
        	window.open(url);
        	document.onmouseup = null;
        }
    }
};

mergeInto(LibraryManager.library, OpenWindowPlugin);
//Source: https://va.lent.in/opening-links-in-a-unity-webgl-project/