/*
' Copyright (c) 2013 Christoc.com Software Solutions
' All rights reserved.
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy of this
' software and associated documentation files (the "Software"), to deal in the Software 
' without restriction, including without limitation the rights to use, copy, modify, merge, 
' publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
' to whom the Software is furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all copies or
' substantial portions of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
' BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
' NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
' DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Christoc.Modules.DnnTaskManagerDal1.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for DNNTaskManagerDal1
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<DNNTaskManagerDal1Info> colDNNTaskManagerDal1s = GetDNNTaskManagerDal1s(ModuleID);
        //if (colDNNTaskManagerDal1s.Count != 0)
        //{
        //    strXML += "<DNNTaskManagerDal1s>";

        //    foreach (DNNTaskManagerDal1Info objDNNTaskManagerDal1 in colDNNTaskManagerDal1s)
        //    {
        //        strXML += "<DNNTaskManagerDal1>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objDNNTaskManagerDal1.Content) + "</content>";
        //        strXML += "</DNNTaskManagerDal1>";
        //    }
        //    strXML += "</DNNTaskManagerDal1s>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlDNNTaskManagerDal1s = DotNetNuke.Common.Globals.GetContent(Content, "DNNTaskManagerDal1s");
        //foreach (XmlNode xmlDNNTaskManagerDal1 in xmlDNNTaskManagerDal1s.SelectNodes("DNNTaskManagerDal1"))
        //{
        //    DNNTaskManagerDal1Info objDNNTaskManagerDal1 = new DNNTaskManagerDal1Info();
        //    objDNNTaskManagerDal1.ModuleId = ModuleID;
        //    objDNNTaskManagerDal1.Content = xmlDNNTaskManagerDal1.SelectSingleNode("content").InnerText;
        //    objDNNTaskManagerDal1.CreatedByUser = UserID;
        //    AddDNNTaskManagerDal1(objDNNTaskManagerDal1);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<DNNTaskManagerDal1Info> colDNNTaskManagerDal1s = GetDNNTaskManagerDal1s(ModInfo.ModuleID);

        //foreach (DNNTaskManagerDal1Info objDNNTaskManagerDal1 in colDNNTaskManagerDal1s)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objDNNTaskManagerDal1.Content, objDNNTaskManagerDal1.CreatedByUser, objDNNTaskManagerDal1.CreatedDate, ModInfo.ModuleID, objDNNTaskManagerDal1.ItemId.ToString(), objDNNTaskManagerDal1.Content, "ItemId=" + objDNNTaskManagerDal1.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
