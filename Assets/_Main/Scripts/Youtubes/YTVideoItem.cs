using System.Collections;
using System.Collections.Generic;
using System;
 
[Serializable]
public class YTVideoItem 
{
    public string kind;
    public string etag;
    public string id;
    public Snippet snippet;
    
    // public int videoId;

}

[Serializable]
public class Snippet{

    public string title;
    public string description;  
    public int position;
    public ResourceId resourceId;  
    public Thumbnail thumbnails;
}

[Serializable]
public class ResourceId{

    public string videoId;
    
}

[Serializable]
public class Thumbnail{

    public Standard standard;
    
}

[Serializable]
public class Standard{

    public string url;
    
}
