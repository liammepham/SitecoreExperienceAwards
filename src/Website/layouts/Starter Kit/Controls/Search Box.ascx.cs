namespace Officecore.Website
{
    using System;
    using System.Drawing;
    using System.Web.UI;

    using Sitecore.Data;
    using Sitecore.Links;

    public partial class LuceneSearchBox : UserControl
    {
        private Database database = Sitecore.Context.Item.Database;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCriteria.Enabled = true;
                txtCriteria.Text = SearchSettings.get("search");
                btnSearch.Enabled = true;
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCriteria.Text != SearchSettings.get("search") && (!string.IsNullOrEmpty(txtCriteria.Text)))
            {
                performSearch(txtCriteria.Text);
            }
        }

        protected void txtCriteria_TextChanged(object sender, EventArgs e)
        {
            if (txtCriteria.Text != SearchSettings.get("search") && (!string.IsNullOrEmpty(txtCriteria.Text)))
            {
                performSearch(txtCriteria.Text);
            }
        }

        private void performSearch(string searchTerm)
        {
            var homeItem = database.GetItem(Sitecore.Context.Site.StartPath);

            if (homeItem != null)
            {
                var resultsItem = homeItem.Axes.SelectSingleItem("./#Standard-Items#/#Search-Results#");

                if (resultsItem != null)
                {
                    string results_url = LinkManager.GetItemUrl(resultsItem) + "?searchStr=" + searchTerm;
                    Response.Redirect(results_url);
                }
                else
                {
                    txtCriteria.ForeColor = Color.Red;
                    txtCriteria.Text = "No search results page";
                }
            }
            else
            {
                txtCriteria.ForeColor = Color.Red;
                txtCriteria.Text = "Unable to find home!";
            }


        }
    }//class
}//namespace

/*
Sitecore Shared Source License

This License governs use of the accompanying Software, and your use of the Software 
constitutes acceptance of this license. 

Subject to the restrictions in this license, you may use this Software for any commercial or 
non-commercial purpose in Sitecore solutions only. You may also distribute this Software with 
books or other teaching materials, or publish the Software on websites, that are intended to 
teach the use of the Software in relation to Sitecore. 

You may not use or distribute this Software or any derivative works in any form for uses other 
than with Sitecore. 

You may modify this Software and distribute the modified Software as long as it relates to 
Sitecore, however, you may not grant rights to the Software or derivative works that are 
broader than those provided by this License. For example, you may not distribute modifications 
of the Software under terms that would permit uses not relating to Sitecore, or under terms 
that purport to require the Software or derivative works to be sublicensed to others. 

You may use any information in intangible form that you remember after accessing the Software. 
However, this right does not grant you a license to any of Sitecore's copyrights or patents 
for anything you might create using such information. 

In return, we simply require that you agree: 

1.	Not to remove any copyright or other notices from the Software.

2.	That if you distribute the Software in source or object form, you will include a verbatim 
    copy of this license. 
    
3.	That if you distribute derivative works of the Software in source code form you do so only 
    under a license that includes all of the provisions of this License, and if you distribute 
    derivative works of the Software solely in object form you do so only under a license that 
    complies with this License. 
    
4.	That if you have modified the Software or created derivative works, and distribute such 
    modifications or derivative works, you will cause the modified files to carry prominent 
    notices so that recipients know that they are not receiving the original Software. Such 
    notices must state: (i) that you have changed the Software; and (ii) the date of any changes. 
    
5.	THAT THE SOFTWARE COMES "AS IS", WITH NO WARRANTIES. THIS MEANS NO EXPRESS, IMPLIED OR 
    STATUTORY WARRANTY, INCLUDING WITHOUT LIMITATION, WARRANTIES OF MERCHANTABILITY OR FITNESS 
    FOR A PARTICULAR PURPOSE OR ANY WARRANTY OF TITLE OR NON-INFRINGEMENT. ALSO, YOU MUST PASS 
    THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE SOFTWARE OR DERIVATIVE WORKS. 
    
6.	THAT SITECORE WILL NOT BE LIABLE FOR ANY DAMAGES RELATED TO THE SOFTWARE OR THIS LICENSE, 
    INCLUDING DIRECT, INDIRECT, SPECIAL, CONSEQUENTIAL OR INCIDENTAL DAMAGES, TO THE MAXIMUM 
    EXTENT THE LAW PERMITS, NO MATTER WHAT LEGAL THEORY IT IS BASED ON. ALSO, YOU MUST PASS 
    THIS LIMITATION OF LIABILITY ON WHENEVER YOU DISTRIBUTE THE SOFTWARE OR DERIVATIVE WORKS. 
    
7.	That if you sue anyone over patents that you think may apply to the Software or anyone's 
    use of the Software, your license to the Software ends automatically. 
    
8.	That your rights under the License end automatically if you breach it in any way. 

9.	Sitecore reserves all rights not expressly granted to you in this license. 

*/