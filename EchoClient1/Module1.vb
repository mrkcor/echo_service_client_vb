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

        Try
            response = client.Echo(request)
            Console.WriteLine("EchoService responded to Echo: " + response.Message)
        Catch sf As System.ServiceModel.FaultException
            Console.WriteLine("SOAP fault: " + sf.Message)
        End Try

        Try
            response = client.ReverseEcho(request)
            Console.WriteLine("EchoService responded to ReverseEcho: " + response.Message)
        Catch sf As System.ServiceModel.FaultException
            Console.WriteLine("SOAP fault: " + sf.Message)
        End Try
    End Sub

End Module
