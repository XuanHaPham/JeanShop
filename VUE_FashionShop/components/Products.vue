<template>
  <div>
    <div class="card-image">
      <figure class="image is-4by3">
        <img src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6271/images/59396/AE6AA6C97CF7DEEE7662EDFD629836B8__55875.1515575456.1280.1280.jpg?c=2" alt="Placeholder image">
      </figure>
    </div>
    <div class="card-content">
      <div class="media">
        <div class="media-content" >
          <p class="title is-4">{{ product.name }}</p>
        </div>
        <div>
          <button class="button is-small" :title="removeFromFavouriteLabel" v-show="product.favourite" @click="removeFromFavourite(product.id)">
            <span class="icon is-small">
              <i class="fa fa-heart"></i>
            </span>
          </button>
          <button class="button is-small" :title="addToFavouriteLabel" v-show="!product.favourite" @click="saveToFavorite(product.id)">
            <span class="icon is-small">
              <i class="fa fa-heart-o"></i>
            </span>
          </button>
          
        </div>
      </div>
      <div class="content is-clearfix"> 
        <p>Code: {{ product.code }}</p>
        <p>{{ product.overview }}</p>
        <p>Size:{{ product.size }}</p>
        <!-- <div class="is-pulled-left">
          <i v-if="product.ratings === 1" class="fa fa-star"></i>
          <i v-if="product.ratings === 2" class="fa fa-star"></i>
          <i v-if="product.ratings === 2" class="fa fa-star"></i>
          <i v-if="product.ratings === 3" class="fa fa-star"></i>
          <i v-if="product.ratings === 3" class="fa fa-star"></i>
          <i v-if="product.ratings === 3" class="fa fa-star"></i>
          <i v-if="product.ratings === 4" class="fa fa-star"></i>
          <i v-if="product.ratings === 4" class="fa fa-star"></i>
          <i v-if="product.ratings === 4" class="fa fa-star"></i>
          <i v-if="product.ratings === 4" class="fa fa-star"></i>
          <i v-if="product.ratings === 5" class="fa fa-star"></i>
          <i v-if="product.ratings === 5" class="fa fa-star"></i>
          <i v-if="product.ratings === 5" class="fa fa-star"></i>
          <i v-if="product.ratings === 5" class="fa fa-star"></i>
          <i v-if="product.ratings === 5" class="fa fa-star"></i>
          <p>{{ product.reviews > 0 ? `${product.reviews} Reviews` : 'No reviews' }}</p>
        </div> -->
        <p class="is-pulled-right">
          <span class="title is-4"><strong>&dollar; {{ product.price }}</strong></span>
        </p>
      </div>
      <div class="card-footer btn-actions">
        <div class="card-footer-item field is-grouped">
          <div class="buttons">
            <button class="button is-primary" v-if="!product.addedToCart" @click="addToCart(product.id)">{{ addToCartLabel }}</button>
            <button class="button is-text" v-if="product.addedToCart" @click="removeFromCart(product.id, false)">{{ removeFromCartLabel }}</button>
          </div>
           <div class="select is-rounded is-small">
            <select @change="onSelectbuyquantity(product.id)" v-model="selected">
              <option v-for="buyquantity in buyquantityArray" :value="buyquantity">{{ buyquantity }}</option>
            </select>
          </div>
        </div>
      </div>
    </div>
    <nuxt-link
      class="details"
      :to="{
        name: 'product_detail-id',
        params: {
          id: product.id,
          title: product.name,
          price: product.price,
          rating: product.ratings,
          reviews: product.reviews,
          addedBtn: product.addedBtn,
          overview: product.overview
        }
      }"
    >
    </nuxt-link>
  </div>
</template>

<script>
export default {
  name: 'products',
  props: ['product'],

  data () {
    return {
      addToCartLabel: 'Add to cart',
      viewDetailsLabel: 'Details',
      removeFromCartLabel: 'Remove from cart',
      addToFavouriteLabel: 'Add to favourite',
      removeFromFavouriteLabel: 'Remove from favourite',
      selected: 1,
      buyquantityArray: []
    }
  },

  mounted () {
    for (let i = 1; i <= this.$props.product.quantity; i++) {
      this.buyquantityArray.push(i);
    }

    if (this.$props.product.buyquantity > 1) {
      this.selected = this.$props.product.buyquantity;
    }
  },

  computed: {
    isUserLogged () {
      return this.$store.getters.isUserLoggedIn;
    }
  },

  methods: {
    addToCart (id) {
      let data = {
        id: id,
        status: true
      }
      this.$store.commit('addToCart', id);
      this.$store.commit('setAddedBtn', data);
    },
    removeFromCart (id) {
      let data = {
        id: id,
        status: false
      }
      this.$store.commit('removeFromCart', id);
      this.$store.commit('setAddedBtn', data);
    },
    saveToFavorite (id) {
      let isUserLogged = this.$store.state.userInfo.isLoggedIn;

      if (isUserLogged) {
        this.$store.commit('addToFavourite', id);
      } else {
        this.$store.commit('showLoginModal', true);
      }
    },
    removeFromFavourite (id) {
      this.$store.commit('removeFromFavourite', id);
    },
    onSelectbuyquantity (id) {
      let data = {
        id: id,
        buyquantity: this.selected
      }
      this.$store.commit('buyquantity', data);
    }
  }
}
</script>

<style lang="scss" scoped>
 .details {
    cursor: pointer;
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 1;

    &:hover {
      border: 1px solid #51bafc;
    }
 }
 .button,
 .select {
   z-index: 2;
 }
 .select {
   position: absolute;
   right: 15px;
   bottom: 35px;
 }
 .card-content {
   padding: 0;
 }
 .buttons {
   margin: 0;
 }
</style>


