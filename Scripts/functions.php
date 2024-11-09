<?php
//to be added in the theme's function file
//regiter custom game score field
function add_game_score_meta_field($user_id) {
    if (!get_user_meta($user_id, 'game_1_score', true)) {
        update_user_meta($user_id, 'game_1_score', 0);
    }
}
add_action('user_register', 'add_game_score_meta_field');

//show the custom field in user profile
function display_game_score_field_in_profile($user) {
    $game_score = get_user_meta($user->ID, 'game_1_score', true);
    ?>
    <h3>Game Score</h3>
    <table class="form-table">
        <tr>
            <th><label for="game_1_score">Game 1 Score</label></th>
            <td>
                <input type="text" name="game_1_score" id="game_1_score" value="<?php echo esc_attr($game_score); ?>" class="regular-text" />
            </td>
        </tr>
    </table>
    <?php
}
add_action('show_user_profile', 'display_game_score_field_in_profile');
add_action('edit_user_profile', 'display_game_score_field_in_profile');

?>