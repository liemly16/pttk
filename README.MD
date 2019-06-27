** Hướng dẫn cài đặt

1. Vào SQL Server tạo database
2. Chạy script_structure.sql để tạo cấu trúc
3. Chạy script_data.sql để tạo dữ liệu mẫu
4. Vào folder PTTK tạo file Web.config từ Web.example.config
5. 
Thay value của giá trị sau đây phù hợp

    <add key="connString" value="Data Source=NEXT-COM\SQLEXPRESS;Initial Catalog=PTTK;Integrated Security=True"/>
