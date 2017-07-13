function createCommentItem(form, path) {
    var service = new ItemService({ url: '/sitecore/api/ssc/item' });
    var obj = {
        ItemName: 'comment - ' + form.name.value,
        TemplateID: '{221F6C57-660A-444E-81E7-586BED2A44A8}',
        Name: form.name.value,
        Comment: form.comment.value,
    };

    service.create(obj)
    .path(path)
    .execute()
    .then(function (item) {
        form.name.value = form.comment.value = '';
        window.alert('Thanks');
    })
    .fail(function (err) {
        window.alert(err);
    });
    return false;
}
