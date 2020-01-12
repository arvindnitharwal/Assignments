namespace Assignments.Entity
{
    public class LinkListNode
    {
       public string ViewCount {get;set;}
       public string ArticleId {get;set;}
       public LinkListNode NextNode {get;set;}
       public LinkListNode(string viewCount,string articleId)
       {
           ViewCount=viewCount;
           ArticleId=articleId;
           NextNode=null;
       }
    }
}