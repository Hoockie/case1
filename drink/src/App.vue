<template>
  <router-view/>
</template>

<style lang="scss">
#app{
  font-family: Avenir, Arial, Helvetica, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: gray;
}

#nav{
  padding: 30px;

  a {
    font-weight: bold;
    color: blue;
     &.router-link-exact-active{
       color: #42b983;
     }
  }
}
</style>