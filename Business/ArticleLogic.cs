using System.Collections.Generic;
using Assignments.Entity;
using System;
namespace  Assignments.Business
{
    public class ArticleLogic : IArticleLogic
    {
        private Dictionary<string,string> ArticleData;
        private LinkListNode TopArticleHead;
        public ArticleLogic()
        {
            ArticleData=GetTestdata();
            TopArticleHead=GetSortedArticle();
        }
        public ArticleResponse GetViewCount(ViewCountRequest request)
        {
            ArticleResponse response =new ArticleResponse();
            response.ArticleIdList=new List<string>();
            if(ArticleData.ContainsKey(request.ArticleId))
            {
                response.ArticleIdList.Add(ArticleData[request.ArticleId]);
                return response;
            }
            else
            {
                return response;
            }
        }
        public ArticleResponse GetTopArticle(TopArticleRequest request)
        {
            ArticleResponse response =new ArticleResponse();
            response.ArticleIdList=new List<string>();
            var topArticle=TopArticleHead;
            int count=0;
            while(count<request.Value && topArticle.NextNode!=null)
            {
                response.ArticleIdList.Add(topArticle.ArticleId);
                count+=1;
                topArticle=topArticle.NextNode;
            }
            return response;
        }
        private LinkListNode GetSortedArticle()
        {
            //check if no ArticleData
            if(ArticleData==null || ArticleData.Count<1)
            {
                return null;
            }
            LinkListNode head=null;
            foreach(var item in ArticleData)
            {
                 var newNode=new LinkListNode(item.Value,item.Key);
                if(head==null)
                {
                    head=newNode;
                }
                else
                {
                    LinkListNode topArticle=head;
                    //check for first node
                    if(StringCompare(item.Value,topArticle.ViewCount))
                    {
                        newNode.NextNode=head;
                        head=newNode;
                    }
                    else
                    {
                        bool isNodeInserted=false;
                        while(topArticle.NextNode!=null && !isNodeInserted)
                        {
                            if(StringCompare(item.Value,topArticle.NextNode.ViewCount))
                            {
                                isNodeInserted=true;
                                newNode.NextNode=topArticle.NextNode;
                                topArticle.NextNode=newNode;
                            }
                            topArticle=topArticle.NextNode;
                        }
                        if(!isNodeInserted)
                        {
                           topArticle.NextNode= newNode;
                        }
                    }
                }
            }
            return head;
        }
        private Dictionary<string,string> GetTestdata()
        {
            Dictionary<string,string> testdata=new Dictionary<string,string>();
            testdata.Add("1","10");
            testdata.Add("2","100");
            testdata.Add("3","101");
            testdata.Add("4","210");
            testdata.Add("5","103");
            testdata.Add("6","140");
            testdata.Add("7","106");
            testdata.Add("8","100");
            testdata.Add("9","1000");
            testdata.Add("10","1089");
            return testdata;
        }
        private bool StringCompare(string a,string b)
        {
            a=a.TrimStart('0');
            b=b.TrimStart('0');
            if(a.Length==b.Length)
            {
               for(int i=0;i<a.Length;i++)
               {
                   int aElement=Convert.ToInt32(a[i]);
                   int bElement=Convert.ToInt32(b[i]);
                   if(aElement>bElement)
                   {
                       return true;
                   }
               }
               return false;
            }
            return a.Length>b.Length;
        }
    }
}