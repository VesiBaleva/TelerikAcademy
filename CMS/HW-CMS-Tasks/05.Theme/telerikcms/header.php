<!DOCTYPE HTML>
<html>

<head>
<title><?php bloginfo('name'); ?> <?php wp_title("",true); ?></title>
<meta name="description" content="website description" />
<meta name="keywords" content="website keywords, website keywords" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<link rel="stylesheet" type="text/css" href="<?php bloginfo('stylesheet_url')?>" />
<!-- modernizr enables HTML5 elements and feature detects -->
<script type="text/javascript" src="<?php echo get_template_directory_uri (); ?>/js/modernizr-1.5.min.js"></script>
<?php wp_head();?>
</head>

<body>
	<div id="main">
		<header>
			<div id="logo">
				<div id="logo_text">
					<!-- class="logo_colour", allows you to change the colour of the text -->
					<h1>
						<a href="index.html">CSS3<span class="logo_colour">_seascape</span>
						</a>
					</h1>
					<h2>Simple. Contemporary. Website Template.</h2>
				</div>
			</div>
			<?php wp_nav_menu(array('theme_location' => 'top-site-menu',
									'container' => 'nav',
									'items_wrap' => '<ul id="nav" class="sf-menu">%3$s</ul>',
									
			))?>;
			<!--  <nav>
				<ul class="sf-menu" id="nav">
					<li class="selected"><a href="index.html">Home</a></li>
					<li><a href="examples.html">Examples</a></li>
					<li><a href="page.html">A Page</a></li>
					<li><a href="another_page.html">Another Page</a></li>
					<li><a href="#">Example Drop Down</a>
						<ul>
							<li><a href="#">Drop Down One</a></li>
							<li><a href="#">Drop Down Two</a>
								<ul>
									<li><a href="#">Sub Drop Down One</a></li>
									<li><a href="#">Sub Drop Down Two</a></li>
									<li><a href="#">Sub Drop Down Three</a></li>
									<li><a href="#">Sub Drop Down Four</a></li>
									<li><a href="#">Sub Drop Down Five</a></li>
								</ul>
							</li>
							<li><a href="#">Drop Down Three</a></li>
							<li><a href="#">Drop Down Four</a></li>
							<li><a href="#">Drop Down Five</a></li>
						</ul>
					</li>
					<li><a href="contact.php">Contact Us</a></li>
				</ul>
			</nav> -->
		</header>
		<div id="site_content">
			<div class="gallery">
				<ul class="images">
					<li class="show"><img width="950" height="300" src="<?php echo get_template_directory_uri (); ?>/images/1.jpg"
						alt="photo_one" /></li>
					<li><img width="950" height="300" src="<?php echo get_template_directory_uri (); ?>/images/2.jpg" alt="seascape" />
					</li>
					<li><img width="950" height="300" src="<?php echo get_template_directory_uri (); ?>/images/3.jpg" alt="seascape" />
					</li>
				</ul>
			</div>
			<?php get_sidebar('right-sidebar');?>
			<div class="content">