'//DotNetNuke - http://www.dotnetnuke.com
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
Imports DotNetNuke

Namespace Data

    ''' <summary>
    ''' An abstract class for the data access layer
    ''' 
    ''' The abstract data provider provides the methods that a control data provider (sqldataprovider)
    ''' must implement. You'll find two commented out examples in the Abstract methods region below.
    ''' </summary>

    Public MustInherit Class DataProvider

#Region "Shared/Static Methods"

        ' singleton reference to the instantiated object 
        Private Shared objProvider As DataProvider = Nothing

        ' constructor
        Shared Sub New()
            CreateProvider()
        End Sub

        ' dynamically create provider
        Private Shared Sub CreateProvider()
            objProvider = CType(Framework.Reflection.CreateObject("data", "DotNetNuke.Modules.VBDnn7TmDal1.Data", ""), DataProvider)
        End Sub

        ' return the provider
        Public Shared Shadows Function Instance() As DataProvider
            Return objProvider
        End Function

#End Region

#Region "Abstract methods"
        Public MustOverride Function GetTasks(ByVal moduleId As Integer) As IDataReader

        Public MustOverride Function GetTask(ByVal taskId As Integer) As IDataReader

        Public MustOverride Sub DeleteTask(ByVal taskId As Integer)

        Public MustOverride Sub DeleteTasks(ByVal moduleId As Integer)

        Public MustOverride Function AddTask(ByVal t As Task) As Integer

        Public MustOverride Sub UpdateTask(ByVal t As Task)
#End Region

    End Class

End Namespace