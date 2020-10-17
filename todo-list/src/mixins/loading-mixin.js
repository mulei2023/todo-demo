 LoadingMixin={
    methods:{
        showLoading(text){
            if(!text){
                text='loading...';
                //show the popup
            }
        },

        hideLoading(){
            //close the popup.
        },
    }
}

export {LoadingMixin};
