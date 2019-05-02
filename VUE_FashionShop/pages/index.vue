<template>
  <div>
    <VmHero></VmHero>
    <div class="columns">
      <div class="column is-one-fifth" style="margin-left:20px;">
          <aside class="menu ">
  <p class="menu-label">
    CLOTHINGS
  </p>
  <ul class="menu-list">
    <li><a>Clothing set</a></li>
    <li><a>Dresses</a></li>
    <li><a>Skirts</a></li>
    <li><a>Shorts</a></li>
    <li><a>Jumpsuit</a></li>
    <li><a>Jackets</a></li>
  </ul>
  <p class="menu-label">
    Swimwear
  </p>
  <ul class="menu-list">
    <li><a>Bundles</a></li>
    <li><a>One pieces</a></li>
    <li><a>Rashguands</a></li>
    <li><a>Bikinis</a></li>
    <li><a>Cover-ups</a></li>
  </ul>
  <p class="menu-label">
    BAGS AND WALLETS
  </p>
  <ul class="menu-list">
    <li><a>Coin Pure</a></li>
    <li><a>Fashion Bags</a></li>
    <li><a>Multipurpose Bags</a></li>
    <li><a>Wallets</a></li>
  </ul>
  <p class="menu-label">
    SHOES
  </p>
  <ul class="menu-list">
    <li><a>Heels</a></li>
    <li><a>Sandals</a></li>
    <li><a>Sneaker</a></li>
  </ul>
</aside>
      </div>
        <div class="column auto">
    <VmProductsList></VmProductsList>
    </div>
    </div>
  </div>
</template>

<script>
import VmProductsList from '@/components/products_list/ProductsListContainer';
import VmHero from '@/components/hero/Hero';

export default {
  name: 'index',
  components: {
    VmProductsList,
    VmHero
  }
};
</script>
