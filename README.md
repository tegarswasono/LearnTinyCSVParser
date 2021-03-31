### <i>Package:</i>
<ol>
  <li>.NetCore 3.1</li>
  <li>TinyCsvParser 2.5.2</li>
</ol>
Untuk Return File CSV tanpa perlu Save di Server Baca Ini <br/>
https://stackoverflow.com/questions/53491070/create-text-file-and-download-without-saving-on-server-in-asp-net-core-mvc-2-1
https://stackoverflow.com/questions/224236/adding-a-newline-into-a-string-in-c-sharp

return Content("foo,bar,baz", "text/csv"); <br/>
return File(Encoding.UTF8.GetBytes(text), "text/plain", "foo.txt"); <br/>
