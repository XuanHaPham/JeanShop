<template>
  <!-- <div class="section">
    <h3 class="title">{{ pageTitle }}</h3>
    <div class="columns is-centered is-multiline">
      <div class="card column is-one-quarter" v-for="product in productsInWishlist" :key="product.id">
        <VmProductsList :product="product"></VmProductsList>
      </div>
      <div class="section" v-if="productsInWishlist.length === 0">
        <p>{{ noProductLabel }}</p>
      </div>
    </div>
  </div> -->
   <section class="section" >
    <div class="container">
      <div class="section-heading" style="text-align:center"> 
        <h3 class="title is-3" >{{ pageTitle }}</h3>
      </div>
      <br>

      <div class="columns">
        <div class="column is-6 is-offset-3">
         

            <div class="field">
              <label class="label">Message</label>
              <div class="control">
                <textarea class="textarea" placeholder="Textarea"></textarea>
              </div>
            </div>

            <div class="field is-grouped has-text-centered">
              <div class="control">
                <button class="button is-link is-large"><span class="icon">
                    <i class="fa fa-envelope"></i>
                  </span>
                  <span>Submit</span></button>
              </div>
            </div>
        </div>
      </div>

    </div>
  </section>

</template>

<script>
import VmProductsList from '@/components/Products';
import { getByTitle } from '@/assets/filters';
import { METHODS } from 'http';
import { isValidEmail } from '@/assets/validators';
export default {
	name: 'feedback',
	data () {
    return {
      pageTitle: 'Feedback Us',
      emailPlaceholder: 'Your email',
    //   noProductLabel: 'Your wishlist is empty'
    }
  },
 methods: {
    checkForm (e) {
      e.preventDefault();


      if (!this.email) {
        this.highlightEmailWithError = true;

        if (this.email && !isValidEmail(this.email)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      } else {
        this.highlightEmailWithError = false;
      }
    },
    checkEmailOnKeyUp (emailValue) {
      if (emailValue && isValidEmail(emailValue)) {
        this.highlightEmailWithError = false;
      } else {
        this.highlightEmailWithError = true;

        if (!isValidEmail(emailValue)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      }
    }
  }
};

</script>

<style lang="scss" scoped>
  .card {
    margin: 10px;
  }
</style>


