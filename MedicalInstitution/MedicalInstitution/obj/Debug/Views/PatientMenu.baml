   M S B A M L   `   `   `  ����M  IMedicalInstitution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MedicalInstitution.ViewsMedicalInstitution.Views  5   	   *    $MedicalInstitution.Views.PatientMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MedicalInstitution.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ PatientMenu��5
   	   $	��550��6   $	��500��6*   .��5      � .+�5   
   �� -   5        $��Napusti��5      $��20q�5      $��Right=�5      $	��Top=�5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� 
�������Odjavite se6<   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ Logout=�6*   $��Center=�5   *   $��20,0,0,0q�5   *   $��25��5   *   $��25��5   *   5      5      �� 5   
   -   5         ��Name$ 
btnPrijavi��5         MaterialDesignRaisedButton#��[  5      $��
0 -200 0 0q�5      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5       �� 	IsDefault . $��45��5!       K� ZIndex$ 1��5"      $
��Bold"�5#      $��18(�5$      
�������$	��300��5&      y�5      ��  �� Path$ enablePrijavi�{�5      �� $ prijavi���5'      �� *Review+	 �� UpdateSourceTrigger$	 PropertyChanged=�.��6Q   Podnesite zahtev za pregled6n   � 5)   
   -   5        
 �Name$
 ReviewResult��5)      $y�	Collapsed=�6%   .+�5*      �� $��2q�6   
������$	��400��6@   $	��300��6L   $��	0 100 0 0q�6Y   ._�5+      �� .+�5,      �� 
������$��20(�66   $��Center=�6D   $��
20 30 20 0q�6a   $
��Wrap=�6u   (&Proveravaju se rezultati sa testiranja6�   �� 5-      
������$��20(�5.       $��Center=�5/       $��	20 0 20 0q�50       $
��Wrap=�51       na Virus COVID-196G   �� 52      
����  �$��20(�53       $��Center=�54       $��
20 30 20 0q�55       $
��Wrap=�56       Molimo Vas za strpljenje. . .6S   � 57      -   5         �Name$ progress��57   .   $��10��6"   $��
50 30 50 0q�6@   6V   �� 58      $ 
Horizontal=�6!   $��Center=�6:   .+�59      �� $��15(�6$   
����  �$��0 10 5 0q�6D   
Preostalo:6c   �� 5:      -   5         ��Name$ loading��5;   $   $��15(�5:   $   
������$��0 10 0 0q�5<   :   36O   5=      �� 5>      -   5         ��Name$ ResultStack��5>   :   $ 
Horizontal=�6!   $y�	Collapsed=�6O   $��Center=�5?   !   .+�5@      �� $��15(�6$   
����  �$��0 30 5 0q�5B   $   Rezultati testa:6I   �� 5C      -   5        $ 
resultTest��5D   $   $��15(�5C   $   
������$��0 30 0 0q�5F   $   	pozitivan6A   5G      5H      5I      5J      5K      5L      