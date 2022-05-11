Module UUID
    Function GenerateGUID()


        Dim sGUID As String
        sGUID = System.Guid.NewGuid.ToString()
        Return sGUID


    End Function
End Module
