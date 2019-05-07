<template>
  <div class="section">
    <div class="card is-clearfix columns">
        <figure class="card-image is-480x480 column is-one-thirds">
          <img src="https://cdn10.bigcommerce.com/s-9ccdlm/products/6271/images/59396/AE6AA6C97CF7DEEE7662EDFD629836B8__55875.1515575456.1280.1280.jpg?c=2">
        </figure>
        <div class="card-content column is-two-thirds">
          <div class="card-content__title">
            <h1 class="title is-4">{{ product.name}}
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
              <h2>
              
            Code: {{ product.code }}
            </h2>
            </h1>
            
          </div>
          <div class="card-content__text">
            
            <p>
           Description: {{ product.description }}
            </p>
            <p>
            Size: {{ product.size }}
            </p>
          </div>
          <!-- <div class="card-content__ratings" v-if="product.rating === 1">
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 2">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 3">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 4">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div>
          <div class="card-content__ratings" v-else-if="product.rating === 5">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
          </div> -->
          <div class="card-content__reviews">
            <!-- <div class="is-pulled-left">
              <p><strong>{{ product.reviews > 0 ? `${product.reviews} Reviews` : 'No reviews' }}</strong></p>
            </div> -->
            <div class="select is-rounded is-small is-pulled-right">
              <select @change="onSelectbuyquantity(product.id)" v-model="selected">
                <option v-for="buyquantity in buyquantityArray" :value="buyquantity">{{ buyquantity }}</option>
              </select>
            </div>
          </div>
          <div class="card-content__price is-pulled-left">
            <span class="title is-3"><strong>{{ product.price }}&dollar;</strong></span>
          </div>
          <div class="card-content__btn is-pulled-right">
            <button class="button is-primary" v-if="!addedBtn" @click="addToCart(product.id)">{{ addToCartLabel }}</button>
            <button class="button is-text" v-if="addedBtn" @click="removeFromCart(product.id)">{{ removeFromCartLabel }}</button>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'product_detail-id',

  validate ({ params }) {
    return /^\d+$/.test(params.id)
  },
  
  data () {
    return {
      addToCartLabel: 'Add to cart',
      removeFromCartLabel: 'Remove from cart',
      addToFavouriteLabel: 'Add to favourite',
      removeFromFavouriteLabel: 'Remove from favourite',
      product: {},
      selected: 1,
      buyquantityArray: []
    };
  },

  mounted () {
    this.product = this.$store.getters.getProductById(this.$route.params.id);
    this.selected = this.product.buyquantity;

    for (let i = 1; i <= this.product.quantity; i++) {
      this.buyquantityArray.push(i);
    }
  },

  computed: {
    addedBtn () {
      return this.product.addedBtn;
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
    onSelectbuyquantity (id) {
      let data = {
        id: id,
        buyquantity: this.selected
      }
      this.$store.commit('buyquantity', data);
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
    }
  }
};
</script>

<style lang="scss" scoped>
  .card-content {
    padding: 15px 10px 15px 0;

    &__text {
      margin: 15px 0;
    }
    &__reviews {
      display: inline-block;
      width: 100%;
      margin-bottom: 10px;
    }
  }
</style>

