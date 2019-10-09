<template>
  <Page>
    <ActionBar title="Welcome" />
    <StackLayout>
      <Label class="message" :text="msg" />
      <Button @tap="loadData" text="Refrescar" />
      <ListView for="t in todos" @tap="onTapped" class="list-group" >
        <v-template>
          <StackLayout class="list-group-item">
            <Label :text="t.name" />
          </StackLayout>
        </v-template>
      </ListView>
    </StackLayout>
  </Page>
</template>

<script>
import * as http from "http";
let URL = "https://a2abdba6.ngrok.io/api/ToDoGet";

export default {
  data() {
    return {
      msg: "Hello World!",
      todos: []
    };
  },
  methods: {
      loadData: function(){
        //http.getJSON(URL)
        http.request({
            url: URL,
            method: "GET"
          })
          .then(
            response => {
              this.msg = "Mi lista"
              this.todos = response.content.toJSON();
              console.log(result.body);
            },
            error => {
              console.log(error);
            }
          );
      },
      onTapped: function(e){
        alert('Elemento seleccionado');
      }
  },
  mounted() {
    this.loadData();
  }
};
</script>

<style scoped>
ActionBar {
  background-color: #53ba82;
  color: #130d0d;
}

.message {
  vertical-align: center;
  text-align: center;
  font-size: 20;
  color: #333333;
}
</style>
