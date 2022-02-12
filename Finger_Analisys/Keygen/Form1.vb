
Public Class Form1
    Dim hw As New clsComputerInfo
    Dim cpu As String
    Dim _hash As New EncrytionHash.Kunci
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

        '    MessageBox.Show(String.Format("The MAC address of {0} is{1}{2}", nic.Description, Environment.NewLine, nic.GetPhysicalAddress()))

        'Next
       
        cpu = hw.GetProcessorId()
        TextBox1.Text = cpu
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        TextBox2.Text = _hash.Encrypt(cpu)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox3.Text = _hash.Encrypt(TextBox2.Text)
    End Sub
End Class
