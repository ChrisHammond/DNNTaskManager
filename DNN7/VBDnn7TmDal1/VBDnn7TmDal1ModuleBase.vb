﻿'//DotNetNuke - http://www.dotnetnuke.com
'// Copyright (c) 2013
'// by DotNetNuke Corporation
'//
'// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
'// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
'// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
'// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'//
'// The above copyright notice and this permission notice shall be included in all copies or substantial portions
'// of the Software.
'//
'// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
'// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
'// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
'// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
'// DEALINGS IN THE SOFTWARE.
Imports DotNetNuke.Entities.Modules


' <summary>
' This base class can be used to define custom properties for multiple controls. 
' An example module, DNNSimpleArticle (http://dnnsimplearticle.codeplex.com) uses this for an ArticleId
' 
' Because the class inherits from PortalModuleBase, properties like ModuleId, TabId, UserId, and others, 
' are accessible to your module's controls (that inherity from VBDnn7TmDal1ModuleBase
' 
' </summary>

Public Class VBDnn7TmDal1ModuleBase
    Inherits PortalModuleBase

    Public ReadOnly Property TaskId() As Integer
        Get
            Dim qs = Request.QueryString("tid")
            If qs IsNot Nothing Then
                Return Convert.ToInt32(qs)
            End If
            Return -1
        End Get
    End Property

End Class
