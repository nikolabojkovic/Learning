//
//  LadmarkRow.swift
//  Landmarks
//
//  Created by Nikola on 4/7/20.
//  Copyright © 2020 Apple. All rights reserved.
//

import SwiftUI

struct LadmarkRow: View {
    var landmark: Landmark
    
    var body: some View {
        HStack {
            landmark.image
                .resizable()
                .frame(width: 50, height: 50)
            Text(landmark.name)
            Spacer()
        }
    }
}

struct LadmarkRow_Previews: PreviewProvider {
    static var previews: some View {
        Group {
            LadmarkRow(landmark: landmarkData[0])
            LadmarkRow(landmark: landmarkData[1])
        }
        .previewLayout(.fixed(width: 300, height: 70))
    }
}
