Module Module1

    Dim client As Echo.EchoPortTypeClient
    Dim request As Echo.EchoMessageType
    Dim response As Echo.EchoMessageType
    Dim message As String

    Sub Main()
        message = Command()
        If message = "" Then
            message = "Hello from VisualBasic"
        End If
        client = New Echo.EchoPortTypeClient()
        request = New Echo.EchoMessageType()
        request.Message = message
        response = client.Echo(request)
        Console.WriteLine(response.Message)
    End Sub

End Module
