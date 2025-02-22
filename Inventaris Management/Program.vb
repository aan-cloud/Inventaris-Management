Imports System
Imports System.IO
Imports System.Collections.Generic

Module EBusinessApp
    ' Simpan produk dalam List
    Dim products As New List(Of String)

    Sub Main()
        Dim pilihan As Integer
        Do
            Console.Clear()
            Console.WriteLine("=== Manajemen Inventaris Toko ===")
            Console.WriteLine("1. Tambah Produk")
            Console.WriteLine("2. Lihat Produk")
            Console.WriteLine("3. Cari Produk")
            Console.WriteLine("4. Hapus Produk")
            Console.WriteLine("5. Simpan ke File")
            Console.WriteLine("6. Baca dari File")
            Console.WriteLine("7. Keluar")
            Console.Write("Pilih Menu: ")

            ' Cek jika input valid
            If Integer.TryParse(Console.ReadLine(), pilihan) Then
                Select Case pilihan
                    Case 1 : TambahProduk()
                    Case 2 : LihatProduk()
                    Case 3 : CariProduk()
                    Case 4 : HapusProduk()
                    Case 5 : SimpanKeFile()
                    Case 6 : BacaDariFile()
                    Case 7 : Exit Do
                    Case Else : Console.WriteLine("Pilihan tidak valid!")
                End Select
            Else
                Console.WriteLine("Input harus angka!")
            End If
            Console.WriteLine("Tekan Enter untuk melanjutkan...")
            Console.ReadLine()
        Loop
    End Sub

    ' Fungsi Tambah Produk
    Sub TambahProduk()
        Console.Write("Masukkan nama produk: ")
        Dim namaProduk As String = Console.ReadLine()
        products.Add(namaProduk)
        Console.WriteLine($"Produk '{namaProduk}' berhasil ditambahkan!")
    End Sub

    ' Fungsi Lihat Produk
    Sub LihatProduk()
        Console.WriteLine("=== Daftar Produk ===")
        If products.Count = 0 Then
            Console.WriteLine("Belum ada produk!")
        Else
            For Each produk In products
                Console.WriteLine($"- {produk}")
            Next
        End If
    End Sub

    ' Fungsi Cari Produk
    Sub CariProduk()
        Console.Write("Masukkan nama produk yang dicari: ")
        Dim cari As String = Console.ReadLine()
        Dim ditemukan As Boolean = False
        For Each produk In products
            If produk.Contains(cari) Then
                Console.WriteLine($"Produk ditemukan: {produk}")
                ditemukan = True
                Exit For
            End If
        Next
        If Not ditemukan Then Console.WriteLine("Produk tidak ditemukan!")
    End Sub

    ' Fungsi Hapus Produk
    Sub HapusProduk()
        Console.Write("Masukkan produk yang ingin dihapus: ")
        Dim hapus As String = Console.ReadLine().ToLower().Trim()

        ' Cari produk dengan case-insensitive
        Dim produkDitemukan As String = products.FirstOrDefault(Function(p) p.ToLower().Trim() = hapus)

        If produkDitemukan IsNot Nothing Then
            products.Remove(produkDitemukan)
            Console.WriteLine($"Produk '{produkDitemukan}' berhasil dihapus!")
        Else
            Console.WriteLine("Produk tidak ditemukan!")
        End If
    End Sub

    ' Fungsi Simpan ke File
    Sub SimpanKeFile()
        File.WriteAllLines("produk.txt", products)
        Console.WriteLine("Data produk berhasil disimpan ke produk.txt!")
    End Sub

    ' Fungsi Baca dari File
    Sub BacaDariFile()
        If File.Exists("produk.txt") Then
            products = File.ReadAllLines("produk.txt").ToList()
            Console.WriteLine("Data produk berhasil dibaca dari file!")
        Else
            Console.WriteLine("File produk.txt tidak ditemukan!")
        End If
    End Sub
End Module

