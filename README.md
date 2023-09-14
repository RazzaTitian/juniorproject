# EasyPlanner
EasyPlanner adalah aplikasi manajemen waktu yang canggih yang memungkinkan pengguna untuk dengan mudah mengelola jadwal harian melalui UI dan UX yang mulus. <br />

NAMA KELOMPOK ANDA <br />
Ketua Kelompok:  Muhammad Razza Titian Jiwani - 21/475348/TK/52470<br />
Anggota 1: Marsellius - 20/456372/TK/50502<br />
Anggota 2: Rajendra Damar Setiyawan - 21/476932/TK/52525<br />

<br />
## Penjelasan Class Diagram <br />
![image](https://github.com/RazzaTitian/juniorproject/assets/93211629/106c9225-ad30-4905-9206-d4ac593a3468)
<br />
<b> Schedule </b> <br />
Atribut <br />
title        : judul kegiatan yang dilakukan <br />
description  : penjelasan singkat kegiatan (optional) <br />
date         : tanggal kegiatan <br />
time         : waktu kegiatan <br />
location     : tempat kegiatan dilaksanakan <br />
Metode <br />
createSchedule()  : membuat kegiatan baru <br />
editSchedule()    : mengubah kegiatan yang sudah ada <br />
deleteSchedule()  : menghapus kegiatan yang sudah ada <br />
<br />
<b> Reminder </b> <br />
Atribut <br />
message  : pesan yang tertulis dalam reminder <br />
date     : tanggal notifikasi reminder muncul <br />
time     : waktu notifikasi reminder muncul <br />
Metode <br />
setReminder()     : membuat reminder baru <br />
editReminder()    : mengubah reminder yang sudah ada <br />
deleteReminder()  : menghapus reminer yang sudah ada <br />
ringReminder()    : menampilkan notifikasi reminder <br />
