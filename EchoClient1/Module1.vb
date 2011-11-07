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
        '
        ' Because the same XML types are used for both the Echo and 
        ' ReverseEcho operation in the XML schema VisualStudio uses
        ' the same classes for the request and response for both 
        ' operations. In this example the request is set once and
        ' is used for calling both Echo and ReverseEcho, and the
        ' same response variable is used to capture the response
        ' for both calls.
        ' Most services that offer multiple operations will use
        ' different XML types for different operations, so you
        ' will not always be able to reuse request and response
        ' variables between operations like done in this example
        request = New Echo.EchoMessageType()
        request.Message = message

        Try
            ' Call Echo and output the result
            response = client.Echo(request)
            Console.WriteLine("EchoService responded to Echo: " + response.Message)
        Catch exception As System.ServiceModel.CommunicationException
            ' In case of an error (SOAP fault or otherwise) output the error
            '
            ' System.ServiceModel.CommunicationException is a generic 
            ' exception that catches a lot of web service related faults, 
            ' if you want you can catch more specific exceptions in your 
            ' code to handle specific faults
            Console.WriteLine("An error occurred while calling Echo on the EchoService: " + exception.Message)
        End Try

        Try
            ' Call ReverseEcho and output the result
            response = client.ReverseEcho(request)
            Console.WriteLine("EchoService responded to ReverseEcho: " + response.Message)
        Catch exception As System.ServiceModel.CommunicationException
            ' In case of an error (SOAP fault or otherwise) output the error
            '
            ' System.ServiceModel.CommunicationException is a generic 
            ' exception that catches a lot of web service related faults, 
            ' if you want you can catch more specific exceptions in your 
            ' code to handle specific faults
            Console.WriteLine("An error occurred while calling ReverseEcho on the EchoService: " + exception.Message)
        End Try
    End Sub

End Module
