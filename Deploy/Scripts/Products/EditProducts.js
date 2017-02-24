//<script type="text/javascript">
$(document).ready(function () {
    $("#Upload").click(function () {
        var formData = new FormData();
        var totalFiles = document.getElementById("FileUpload").files.length;
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("FileUpload").files[i];

            formData.append("FileUpload", file);
        }
        $.ajax({
            type: "POST",
            url: '/Products/Upload',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                alert('Upload Photo Succes!!');
            },
            error: function (error) {
                alert("Upload Process Errror !");
            }
        });
    });
});
//</script>