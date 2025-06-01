package mpackage;

import java.awt.Color;
import java.awt.event.ActionEvent;
//import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import org.apache.pdfbox.pdmodel.PDDocument;

import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
public class Conversor extends WindowApp implements Fontes {



    public Conversor() {
        window = new JFrame("Conversor para PDF");

        window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        window.setSize(400, 400);
        window.setLayout(null);
        window.getContentPane().setBackground(Color.LIGHT_GRAY);
        container = window.getContentPane();
    
    // -------------------------------------------------------------------------- //

        panel = new JPanel();
        panel.setBounds(17, 100, 350, 110);
        panel.setBackground(Color.LIGHT_GRAY);

        titleText = new JLabel("Escolha o arquivo para conversão:");
        titleText.setForeground(Color.black);
        titleText.setFont(NORMAL_FONT);

        selectArc = new JButton("Selecionar arquivo");
        selectArc.setBounds(100, 110, 150, 50);
        selectArc.setFont(BOLD_FONT);

        //panel2 = new JPanel();

        //panel2.setBounds(40, 180, 300, 70);
        //panel2.setBackground(Color.black);

        //dirText = new JLabel("Diretório para salvar o PDF:");
        //dirText.setForeground(Color.white);
        //dirText.setFont(NORMAL_FONT);
        
        //selectButton = new JButton("Selecionar diretório");
        //selectButton.setBounds(100, 350, 150, 20);
        //selectButton.setFont(BOLD_FONT);

        JLabel selectedArc = new JLabel("");
        selectedArc.setForeground(Color.white);
        selectedArc.setFont(SELECT_FONT);
        selectedArc.setBounds(0, 0, 10, 0);
        
        selectArc.addActionListener((ActionEvent e) -> {
            JFileChooser fileChooser = new JFileChooser();
            int result = fileChooser.showOpenDialog(window);
            if (result == JFileChooser.APPROVE_OPTION) {
                File selectedFile = fileChooser.getSelectedFile();
                
                try {
                    if (selectedFile.getName().toLowerCase().endsWith(".txt")) {
                        PDDocument document = new PDDocument();
                        PDPage page = new PDPage(PDRectangle.A4);
                        document.addPage(page);
                        
                        PDPageContentStream content = new PDPageContentStream(document, page);
                        content.beginText();
                        content.setFont(PDType1Font, 12);
                        content.setLeading(14.5f);
                        content.newLineAtOffset(50, 750);
                        
                        BufferedReader buffer = new BufferedReader(new FileReader(selectedFile));
                        String line;
                        int lineCount = 0;
                        
                        
                        while ((line = buffer.readLine()) != null) {
                            if (lineCount * 14.5f > 700) {
                                content.endText();
                                content.close();
                                
                                page = new PDPage(PDRectangle.A4);
                                document.addPage(page);
                                content = new PDPageContentStream(document, page);
                                content.beginText();
                                content.setLeading(14.5f);
                                content.setFont(PDType1Font, 12);
                                content.newLineAtOffset(50, 750);
                                lineCount = 0;
                            }
                            
                            content.showText(line);
                            content.newLine();
                            lineCount++;
                        }
                        
                        buffer.close();
                        content.endText();
                        content.close();
                        
                        String outputFileName = selectedFile.getParent() + "/" + selectedFile.getName().replace(".txt", ".pdf");
                        document.save(outputFileName);
                        document.close();
                        
                        JOptionPane.showMessageDialog(null, "Arquivo convertido com sucesso: " + outputFileName);
                        
                        
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                    JOptionPane.showMessageDialog(null, "Erro ao converter o arquivo");
                }
                
            } else {
                
                JOptionPane.showMessageDialog(null, "Por favor, selecione um arquivo");
            }
            
            
        });
        
        
        panel.add(titleText);
        panel.add(selectArc);
        panel.add(selectedArc);
        container.add(panel);
        //panel2.add(dirText);
        //panel2.add(selectButton);
        //container.add(panel2);
        window.setVisible(true);
    }
}