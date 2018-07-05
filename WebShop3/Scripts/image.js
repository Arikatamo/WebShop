$(function () {
    $('#img_file').on('change', function ()
    {
        if (this.files && this.files[0]) {
            if (this.files[0].type.match(/^image\//))
            {
                var reader = new FileReader();
                reader.onload = function (e)
                {
                    var img = new Image();
                    img.onload = function ()
                    {
                        $('#resultImg').html($('<img style="width:150px" name="ImagePath">').attr('src', this.files[0]));
                        $('#ImagePath').attr("value", this.files[0])

                    }
                    img.src = e.target.result;
                }
                reader.readAsDataURL(this.files[0]);

            }
        }
    });
});