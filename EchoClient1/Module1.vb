Module Module1

    Dim client As Echo.EchoPortTypeClient
    Dim request As Echo.EchoMessageType
    Dim response As Echo.EchoMessageType
    Dim message As String

    Sub Main()
        ' If command line arguments were given then they are used
        ' as message to the EchoService
        message = Command()

        ' If no command line arguments were given then default the
        ' message to "Hello from VisualBasic"
        If message = "" Then
            message = "Hello from VisualBasic"
        End If

        ' Instantiate new EchoService client
        client = New Echo.EchoPortTypeClient()

        ' Instantiate the request object and set the message within it
        request = New Echo.EchoMessageType()
        request.Message = message

        Try
            ' Call Echo and output the result
            response = client.Echo(request)
            Console.WriteLine("EchoService responded to Echo: " + response.Message)
        Catch exception As System.ServiceModel.CommunicationException
            ' In case of an error (SOAP fault or otherwise) output the error
            Console.WriteLine("An error occurred while calling Echo on the EchoService: " + exception.Message)
        End Try

        Try
            ' Call ReverseEcho and output the result
            response = client.ReverseEcho(request)
            Console.WriteLine("EchoService responded to ReverseEcho: " + response.Message)
        Catch exception As System.ServiceModel.CommunicationException
            ' In case of an error (SOAP fault or otherwise) output the error
            Console.WriteLine("An error occurred while calling ReverseEcho on the EchoService: " + exception.Message)
        End Try
    End Sub

End Module
