import bpy

bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, 0, -0.1), rotation=(0, 0, 0), scale=(5, 8, 0.1))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, -7.9, 5), rotation=(0, 0, 0), scale=(5, 0.1, 5))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, 7.9, 1.5), rotation=(0, 0, 0), scale=(5, 0.1, 1.5))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(4.9, 0, 1.5), rotation=(0, 0, 0), scale=(0.1, 7.8, 1.5))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(-4.9, 0, 1.5), rotation=(0, 0, 0), scale=(0.1, 7.8, 1.5))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, -2, 6), rotation=(0, 0, 0), scale=(4.8, 0.1, 3))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, -6.3, 9), rotation=(0, 0, 0), scale=(4.8, 1.5, 0.1))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, -3.6, 6.5), rotation=(0, 0, 0), scale=(4.8, 1.5, 0.1))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(0, -4.8, 4), rotation=(0, 0, 0), scale=(4.8, 3, 0.1))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(4.9, -4.85, 8.5), rotation=(0, 0, 0), scale=(0.1, 2.925, 3.5))
bpy.ops.mesh.primitive_cube_add(size=2, enter_editmode=False, location=(-4.9, -4.85, 8.5), rotation=(0, 0, 0), scale=(0.1, 2.925, 3.5))

#bpy.ops.transform.translate(value=(-0, -0, -2), orient_type='GLOBAL', orient_matrix=((1, 0, 0), (0, 1, 0), (0, 0, 1)), orient_matrix_type='GLOBAL', constraint_axis=(False, False, True), mirror=True, use_proportional_edit=False, proportional_edit_falloff='SMOOTH', proportional_size=1, use_proportional_connected=False, use_proportional_projected=False, release_confirm=True)
#bpy.ops.transform.translate(value=(-0, -0, -3), orient_type='GLOBAL', orient_matrix=((1, 0, 0), (0, 1, 0), (0, 0, 1)), orient_matrix_type='GLOBAL', constraint_axis=(False, False, True), mirror=True, use_proportional_edit=False, proportional_edit_falloff='SMOOTH', proportional_size=1, use_proportional_connected=False, use_proportional_projected=False, release_confirm=True)