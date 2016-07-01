Imports System.Threading
Imports System.Runtime.InteropServices

Public Class Form1

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const PAGE_READWRITE = 4
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)

    Public Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer As String, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
    Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Integer
    Public Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As Integer, ByVal lpAddress As Integer, ByVal dwSize As Integer, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As Integer
    Public Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer As String, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
    Public Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Integer, ByVal lpProcName As String) As Integer
    Private Declare Function GetModuleHandle Lib "Kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Integer
    Public Declare Function CreateRemoteThread Lib "kernel32" (ByVal hProcess As Integer, ByVal lpThreadAttributes As Integer, ByVal dwStackSize As Integer, ByVal lpStartAddress As Integer, ByVal lpParameter As Integer, ByVal dwCreationFlags As Integer, ByRef lpThreadId As IntPtr) As Integer
    Public Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandleA" (ByVal hObject As Integer) As Integer

    'Dim LauncherPath As String = "F:\SteamLibrary\steamapps\common\Warhammer End Times Vermintide\launcher\launcher.exe"
    'Dim VermintidePath As String = "F:\SteamLibrary\steamapps\common\Warhammer End Times Vermintide\binaries\vermintide.exe"
    'Dim VermintideDLL As String = "C:\Users\Dude\Desktop\Vermintide\vermintide_new.dll"
    Dim DLLPath As String
    Dim VermintideName As String = "vermintide"
    Dim VermintideProcess As Process

    Private Sub Inject()
        Try
            'Inject Dll
            Dim lpThreadId As IntPtr
            Dim TargetProcessHandle As Integer = OpenProcess(&H1F0FFF, 0, VermintideProcess.Id)
            Dim pszLibFileRemote As String = (DLLPath)
            Dim pfnStartAddr As Integer = GetProcAddress(GetModuleHandle("Kernel32"), "LoadLibraryA")
            Dim TargetBufferSize As Integer = 1 + Len(pszLibFileRemote)
            Dim Rtn As Integer
            Dim LoadLibParamAdr As Integer
            LoadLibParamAdr = VirtualAllocEx(TargetProcessHandle, 0, TargetBufferSize, MEM_COMMIT, PAGE_READWRITE)
            Rtn = WriteProcessMemory(TargetProcessHandle, LoadLibParamAdr, pszLibFileRemote, TargetBufferSize, 0)
            CreateRemoteThread(TargetProcessHandle, 0, 0, pfnStartAddr, LoadLibParamAdr, 0, lpThreadId)            
            ' Panels
            'pnl_injecting.Visible = False
            'pnl_injected.Visible = True
            SwitchPanel(Panel.Injected)
            Update_Injected(VermintideProcess)            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InjectTimer.Start()
        DLLPath = Application.StartupPath + "\vermintide_new.dll"
Browse:
        If Not My.Computer.FileSystem.FileExists(DLLPath) Then
            Dim FindDLL As New OpenFileDialog
            FindDLL.Title = "Open DLL to inject"
            FindDLL.Filter = "(*.dll)|*.dll"
            If FindDLL.ShowDialog() = Windows.Forms.DialogResult.OK Then
                DLLPath = FindDLL.FileName
            End If
        End If
        If Not My.Computer.FileSystem.FileExists(DLLPath) Then
            If MsgBox("DLL not found", MsgBoxStyle.RetryCancel, "DLL not found") = MsgBoxResult.Retry Then
                GoTo Browse
            Else
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub InjectTimer_Tick(sender As Object, e As EventArgs) Handles InjectTimer.Tick
        Dim check_process As Process() = Process.GetProcessesByName(VermintideName)
        If check_process.Length > 0 Then
            VermintideProcess = check_process(0)
            ' Timers
            InjectTimer.Stop()
            DelayTimer.Start()
            EndTimer.Start()
            ' Panels
            SwitchPanel(Panel.Injecting)
        End If
    End Sub

    Private Sub DelayTimer_Tick(sender As Object, e As EventArgs) Handles DelayTimer.Tick
        If Not IsNothing(VermintideProcess) Then
            DelayTimer.Stop()
            Inject()
        End If
    End Sub

    Private Sub EndTimer_Tick(sender As Object, e As EventArgs) Handles EndTimer.Tick
        If VermintideProcess.HasExited Then
            VermintideProcess = Nothing
            InjectTimer.Start()
            EndTimer.Stop()
            SwitchPanel(Panel.Searching)
        End If
    End Sub

    Private Sub AnimateTimer_Tick(sender As Object, e As EventArgs) Handles AnimateTimer.Tick
        If pnl_searching.Visible Then
            If pb_searching.Value < pb_searching.Maximum Then
                pb_searching.Value += 1
            Else
                pb_searching.Value = pb_searching.Minimum
            End If
        End If
        If pnl_injecting.Visible Then
            If pb_injecting.Value < pb_injecting.Maximum Then
                pb_injecting.Value += 1
            Else
                pb_injecting.Value = pb_injecting.Minimum
            End If
        End If
    End Sub

    Private Sub pnl_searching_SizeChanged(sender As Object, e As EventArgs) Handles pnl_searching.SizeChanged
        FitSearch()
    End Sub

    Private Sub FitSearch()
        If pnl_searching.Width > 0 Then
            pb_searching.Width = pnl_searching.Width / 4
            pb_searching.Left = pnl_searching.Width / 2 - pb_searching.Width / 2
            lbl_searching.Left = pnl_searching.Width / 2 - lbl_searching.Width / 2
        End If
    End Sub

    Private Sub FitInject()
        If pnl_injected.Width > 0 Then
            pb_injecting.Width = pnl_injected.Width / 4
            pb_injecting.Left = pnl_injected.Width / 2 - pb_injecting.Width / 2
            lbl_injecting.Left = pnl_injected.Width / 2 - lbl_injecting.Width / 2
        End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FitSearch()
        FitInject()
        pnl_injected.Visible = False
        pnl_injecting.Visible = False
        pnl_injected.Location = pnl_injecting.Location
        pnl_searching.Location = pnl_injected.Location

    End Sub

    Private Sub Update_Injected(ByRef Process As Process)
        lbl_process_id.Text = "Process ID: " + Process.Id.ToString
        lbl_process_name.Text = "Process Name: " + Process.ProcessName
    End Sub

    Private Sub pnl_injecting_SizeChanged(sender As Object, e As EventArgs) Handles pnl_injecting.SizeChanged
        FitInject()
    End Sub

    Private Enum Panel
        Searching
        Injecting
        Injected
    End Enum
    Private Sub SwitchPanel(ByVal Panel As Panel)
        Select Case Panel
            Case Form1.Panel.Searching
                pnl_searching.Visible = True                
                pnl_injecting.Visible = False
                pnl_injected.Visible = False
                pnl_searching.BringToFront()
            Case Form1.Panel.Injecting
                pnl_injecting.Visible = True
                pnl_searching.Visible = False
                pnl_injected.Visible = False
                pnl_injecting.BringToFront()
            Case Form1.Panel.Injected
                pnl_injected.Visible = True
                pnl_searching.Visible = False
                pnl_injecting.Visible = False
                pnl_injected.BringToFront()
        End Select
    End Sub

    ''Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    'Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, ByVal lpsz2 As String) As Long
    'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As String) As Long
    '<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    'Private Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    'End Function
    'Private Const EM_REPLACESEL = &HC2
    'Private Const VK_INSERT As Integer = &H2D
    'Private Const WM_KEYDOWN = &H100
    'Private Const WM_KEYUP = &H101

    'Private Sub Send()

    '    Dim ret As Long = PostMessage(VermintideProcess.MainWindowHandle, WM_KEYDOWN, VK_INSERT, 0)


    '    'Dim nPadHwnd As Long = FindWindow("vermintide", "vermintide")
    '    'If nPadHwnd > 0 Then
    '    '    Dim EditHwnd As Long = FindWindowEx(nPadHwnd, 0&, "Edit", vbNullString)
    '    '    If EditHwnd > 0 Then
    '    '        'Dim ret As Long = SendMessage(EditHwnd, EM_REPLACESEL, 0, Mid$(SendString, CharPos, 1))
    '    '        Dim ret As Long = SendMessage(EditHwnd, WM_KEYDOWN, VK_INSERT, 0)
    '    '        ret = SendMessage(EditHwnd, WM_KEYUP, VK_INSERT, 0)
    '    '    End If
    '    'Else
    '    '    MsgBox("Untitled - Notepad was not found!", vbInformation)
    '    'End If
    'End Sub

End Class
